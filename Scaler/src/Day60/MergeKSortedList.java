package Day60;

import java.util.*;

public class MergeKSortedList {

	public ListNode mergeKLists(ArrayList<ListNode> a) {
		PriorityQueue<ListNode> pq = new PriorityQueue<>((head1, head2) -> head1.val - head2.val);
        for(ListNode listHead : a) {
            pq.add(listHead);
        }
        ListNode ans = new ListNode(-1);
        ListNode temp = ans;
        while(!pq.isEmpty()) {
            ListNode minNode = pq.poll();
            temp.next = minNode;
            temp = temp.next;
            if(minNode.next != null) {
                pq.add(minNode.next);
            }
        }
        return ans.next;
	}
}
